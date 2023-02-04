using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace StalcraftSharp.Core.Protocol
{
    public class HttpRequestBuilder
    {
        #region Enumerations
        public enum HttpMethods
        {
            Get,
            Post
        }

        public enum ParameterModes
        {
            Query,
            Form,
        }
        #endregion

        #region Instance Fields
        private HttpMethod _httpMethod;
        private Uri _requestUri;
        private List<string> _paths;
        private ParameterModes _parameterMode;
        private Dictionary<string, string> _parameters;
        #endregion

        #region Constructors
        public HttpRequestBuilder(HttpMethods httpMethod = HttpMethods.Get, string uri = null, ParameterModes parameterMode = ParameterModes.Query)
        {
            this.SetRequestUri(uri);
            this.SetHttpMethod(httpMethod);
            this.SetParameterMode(parameterMode);
            this._paths = new List<string>();
            this._parameters = new Dictionary<string, string>();
        }
        #endregion

        public HttpRequestBuilder SetHttpMethod(HttpMethods method)
        {
            switch (method)
            {
                case HttpMethods.Get:
                    this._httpMethod = HttpMethod.Get;
                    break;
                case HttpMethods.Post:
                    this._httpMethod = HttpMethod.Post;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return this;
        }

        public HttpRequestBuilder SetRequestUri(string requestUri)
        {
            if (string.IsNullOrWhiteSpace(requestUri))
            {
                throw new ArgumentNullException(nameof(requestUri));
            }

            return this.SetRequestUri(new Uri(requestUri));
        }

        public HttpRequestBuilder SetRequestUri(Uri requestUri)
        {
            if (requestUri == null)
            {
                throw new ArgumentNullException(nameof(requestUri));
            }

            this._requestUri = requestUri;

            return this;
        }

        public HttpRequestBuilder AddPath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            this._paths.Add(path);

            return this;
        }

        public HttpRequestBuilder AddParameter(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            this._parameters.Add(key, value);
            return this;
        }

        public HttpRequestBuilder SetParameterMode(ParameterModes mode)
        {
            this._parameterMode = mode;

            return this;
        }

        public HttpRequestBuilder AddParameter(KeyValuePair<string, string> pair)
            => this.AddParameter(pair.Key, pair.Value);

        public HttpRequestMessage Build()
        {
            if (this._httpMethod == null)
            {
                throw new ArgumentNullException("httpMethod");
            }

            if (this._requestUri == null)
            {
                throw new ArgumentNullException("requestUri");
            }

            // Vars
            var uriBuilder = new UriBuilder(this._requestUri);

            // Build the uri path
            var pathBuilder = new StringBuilder(uriBuilder.Path);
            foreach (var path in this._paths)
            {
                if (pathBuilder.Length == 0)
                {
                    if (path[0] != '/')
                    {
                        pathBuilder.Append('/');
                    }
                }
                else
                {
                    if (pathBuilder[pathBuilder.Length - 1] == '/' && path[0] == '/')
                    {
                        pathBuilder.Remove(pathBuilder.Length - 1, 1);
                    }
                    else if (pathBuilder[pathBuilder.Length - 1] != '/' && path[0] != '/')
                    {
                        pathBuilder.Append('/');
                    }
                }
                pathBuilder.Append(path);
            }
            uriBuilder.Path = pathBuilder.ToString();

            // Setup content
            var content = default(HttpContent);
            if (this._parameters.Count > 0)
            {
                if (this._parameterMode.Equals(ParameterModes.Form))
                {
                    content = new FormUrlEncodedContent(this._parameters);
                }
                else
                {
                    var queryBuilder = new StringBuilder(uriBuilder.Query);
                    foreach (var parameter in this._parameters)
                    {
                        if (queryBuilder.Length == 0)
                        {
                            queryBuilder.Append('?');
                        }
                        else
                        {
                            queryBuilder.Append('&');
                        }

                        queryBuilder.AppendFormat("{0}={1}", parameter.Key, Uri.EscapeDataString(parameter.Value));
                    }
                    uriBuilder.Query = queryBuilder.ToString();
                }
            }

            return new HttpRequestMessage
            {
                Method = this._httpMethod,
                RequestUri = uriBuilder.Uri,
                Content = content,
            };
        }

        public override string ToString()
            => this.Build().RequestUri.ToString();
    }
}
