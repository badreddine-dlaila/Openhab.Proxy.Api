/* 
 * openHAB REST API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 2.5
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Openhab.Client.Client;
using Openhab.Client.Model;
using RestSharp;

namespace Openhab.Client.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IBindingsApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get all bindings.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="acceptLanguage">language (optional)</param>
        /// <returns>List&lt;BindingInfoDTO&gt;</returns>
        List<BindingInfoDTO> GetAll (string acceptLanguage = null);

        /// <summary>
        /// Get all bindings.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="acceptLanguage">language (optional)</param>
        /// <returns>ApiResponse of List&lt;BindingInfoDTO&gt;</returns>
        ApiResponse<List<BindingInfoDTO>> GetAllWithHttpInfo (string acceptLanguage = null);
        /// <summary>
        /// Get binding configuration for given binding ID.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="bindingId">service ID</param>
        /// <returns>string</returns>
        string GetConfiguration (string bindingId);

        /// <summary>
        /// Get binding configuration for given binding ID.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="bindingId">service ID</param>
        /// <returns>ApiResponse of string</returns>
        ApiResponse<string> GetConfigurationWithHttpInfo (string bindingId);
        /// <summary>
        /// Updates a binding configuration for given binding ID and returns the old configuration.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="bindingId">service ID</param>
        /// <param name="body"> (optional)</param>
        /// <returns>string</returns>
        string UpdateConfiguration (string bindingId, object body = null);

        /// <summary>
        /// Updates a binding configuration for given binding ID and returns the old configuration.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="bindingId">service ID</param>
        /// <param name="body"> (optional)</param>
        /// <returns>ApiResponse of string</returns>
        ApiResponse<string> UpdateConfigurationWithHttpInfo (string bindingId, object body = null);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Get all bindings.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="acceptLanguage">language (optional)</param>
        /// <returns>Task of List&lt;BindingInfoDTO&gt;</returns>
        System.Threading.Tasks.Task<List<BindingInfoDTO>> GetAllAsync (string acceptLanguage = null);

        /// <summary>
        /// Get all bindings.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="acceptLanguage">language (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;BindingInfoDTO&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<BindingInfoDTO>>> GetAllAsyncWithHttpInfo (string acceptLanguage = null);
        /// <summary>
        /// Get binding configuration for given binding ID.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="bindingId">service ID</param>
        /// <returns>Task of string</returns>
        System.Threading.Tasks.Task<string> GetConfigurationAsync (string bindingId);

        /// <summary>
        /// Get binding configuration for given binding ID.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="bindingId">service ID</param>
        /// <returns>Task of ApiResponse (string)</returns>
        System.Threading.Tasks.Task<ApiResponse<string>> GetConfigurationAsyncWithHttpInfo (string bindingId);
        /// <summary>
        /// Updates a binding configuration for given binding ID and returns the old configuration.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="bindingId">service ID</param>
        /// <param name="body"> (optional)</param>
        /// <returns>Task of string</returns>
        System.Threading.Tasks.Task<string> UpdateConfigurationAsync (string bindingId, object body = null);

        /// <summary>
        /// Updates a binding configuration for given binding ID and returns the old configuration.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="bindingId">service ID</param>
        /// <param name="body"> (optional)</param>
        /// <returns>Task of ApiResponse (string)</returns>
        System.Threading.Tasks.Task<ApiResponse<string>> UpdateConfigurationAsyncWithHttpInfo (string bindingId, object body = null);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class BindingsApi : IBindingsApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="BindingsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BindingsApi(string basePath)
        {
            Configuration = new Configuration { BasePath = basePath };

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BindingsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public BindingsApi(Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                Configuration = Configuration.Default;
            else
                Configuration = configuration;

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(string basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<string, string> DefaultHeader()
        {
            return new ReadOnlyDictionary<string, string>(Configuration.DefaultHeader);
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// Get all bindings. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="acceptLanguage">language (optional)</param>
        /// <returns>List&lt;BindingInfoDTO&gt;</returns>
        public List<BindingInfoDTO> GetAll (string acceptLanguage = null)
        {
             ApiResponse<List<BindingInfoDTO>> localVarResponse = GetAllWithHttpInfo(acceptLanguage);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get all bindings. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="acceptLanguage">language (optional)</param>
        /// <returns>ApiResponse of List&lt;BindingInfoDTO&gt;</returns>
        public ApiResponse< List<BindingInfoDTO> > GetAllWithHttpInfo (string acceptLanguage = null)
        {

            var localVarPath = "/bindings";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json"
            };
            string localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (acceptLanguage != null) localVarHeaderParams.Add("Accept-Language", Configuration.ApiClient.ParameterToString(acceptLanguage)); // header parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetAll", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<BindingInfoDTO>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<BindingInfoDTO>) Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<BindingInfoDTO>)));
        }

        /// <summary>
        /// Get all bindings. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="acceptLanguage">language (optional)</param>
        /// <returns>Task of List&lt;BindingInfoDTO&gt;</returns>
        public async System.Threading.Tasks.Task<List<BindingInfoDTO>> GetAllAsync (string acceptLanguage = null)
        {
             ApiResponse<List<BindingInfoDTO>> localVarResponse = await GetAllAsyncWithHttpInfo(acceptLanguage);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get all bindings. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="acceptLanguage">language (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;BindingInfoDTO&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<BindingInfoDTO>>> GetAllAsyncWithHttpInfo (string acceptLanguage = null)
        {

            var localVarPath = "/bindings";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json"
            };
            string localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (acceptLanguage != null) localVarHeaderParams.Add("Accept-Language", Configuration.ApiClient.ParameterToString(acceptLanguage)); // header parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetAll", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<BindingInfoDTO>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<BindingInfoDTO>) Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<BindingInfoDTO>)));
        }

        /// <summary>
        /// Get binding configuration for given binding ID. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="bindingId">service ID</param>
        /// <returns>string</returns>
        public string GetConfiguration (string bindingId)
        {
             ApiResponse<string> localVarResponse = GetConfigurationWithHttpInfo(bindingId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get binding configuration for given binding ID. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="bindingId">service ID</param>
        /// <returns>ApiResponse of string</returns>
        public ApiResponse< string > GetConfigurationWithHttpInfo (string bindingId)
        {
            // verify the required parameter 'bindingId' is set
            if (bindingId == null)
                throw new ApiException(400, "Missing required parameter 'bindingId' when calling BindingsApi->GetConfiguration");

            var localVarPath = "/bindings/{bindingId}/config";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json"
            };
            string localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (bindingId != null) localVarPathParams.Add("bindingId", Configuration.ApiClient.ParameterToString(bindingId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetConfiguration", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<string>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (string) Configuration.ApiClient.Deserialize(localVarResponse, typeof(string)));
        }

        /// <summary>
        /// Get binding configuration for given binding ID. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="bindingId">service ID</param>
        /// <returns>Task of string</returns>
        public async System.Threading.Tasks.Task<string> GetConfigurationAsync (string bindingId)
        {
             ApiResponse<string> localVarResponse = await GetConfigurationAsyncWithHttpInfo(bindingId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get binding configuration for given binding ID. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="bindingId">service ID</param>
        /// <returns>Task of ApiResponse (string)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<string>> GetConfigurationAsyncWithHttpInfo (string bindingId)
        {
            // verify the required parameter 'bindingId' is set
            if (bindingId == null)
                throw new ApiException(400, "Missing required parameter 'bindingId' when calling BindingsApi->GetConfiguration");

            var localVarPath = "/bindings/{bindingId}/config";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json"
            };
            string localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (bindingId != null) localVarPathParams.Add("bindingId", Configuration.ApiClient.ParameterToString(bindingId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetConfiguration", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<string>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (string) Configuration.ApiClient.Deserialize(localVarResponse, typeof(string)));
        }

        /// <summary>
        /// Updates a binding configuration for given binding ID and returns the old configuration. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="bindingId">service ID</param>
        /// <param name="body"> (optional)</param>
        /// <returns>string</returns>
        public string UpdateConfiguration (string bindingId, object body = null)
        {
             ApiResponse<string> localVarResponse = UpdateConfigurationWithHttpInfo(bindingId, body);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Updates a binding configuration for given binding ID and returns the old configuration. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="bindingId">service ID</param>
        /// <param name="body"> (optional)</param>
        /// <returns>ApiResponse of string</returns>
        public ApiResponse< string > UpdateConfigurationWithHttpInfo (string bindingId, object body = null)
        {
            // verify the required parameter 'bindingId' is set
            if (bindingId == null)
                throw new ApiException(400, "Missing required parameter 'bindingId' when calling BindingsApi->UpdateConfiguration");

            var localVarPath = "/bindings/{bindingId}/config";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
                "application/json"
            };
            string localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json"
            };
            string localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (bindingId != null) localVarPathParams.Add("bindingId", Configuration.ApiClient.ParameterToString(bindingId)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("UpdateConfiguration", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<string>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (string) Configuration.ApiClient.Deserialize(localVarResponse, typeof(string)));
        }

        /// <summary>
        /// Updates a binding configuration for given binding ID and returns the old configuration. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="bindingId">service ID</param>
        /// <param name="body"> (optional)</param>
        /// <returns>Task of string</returns>
        public async System.Threading.Tasks.Task<string> UpdateConfigurationAsync (string bindingId, object body = null)
        {
             ApiResponse<string> localVarResponse = await UpdateConfigurationAsyncWithHttpInfo(bindingId, body);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Updates a binding configuration for given binding ID and returns the old configuration. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="bindingId">service ID</param>
        /// <param name="body"> (optional)</param>
        /// <returns>Task of ApiResponse (string)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<string>> UpdateConfigurationAsyncWithHttpInfo (string bindingId, object body = null)
        {
            // verify the required parameter 'bindingId' is set
            if (bindingId == null)
                throw new ApiException(400, "Missing required parameter 'bindingId' when calling BindingsApi->UpdateConfiguration");

            var localVarPath = "/bindings/{bindingId}/config";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
                "application/json"
            };
            string localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json"
            };
            string localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (bindingId != null) localVarPathParams.Add("bindingId", Configuration.ApiClient.ParameterToString(bindingId)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("UpdateConfiguration", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<string>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (string) Configuration.ApiClient.Deserialize(localVarResponse, typeof(string)));
        }

    }
}
