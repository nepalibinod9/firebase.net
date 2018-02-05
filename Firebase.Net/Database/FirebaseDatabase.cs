using System;
using System.Net.Http;

namespace Firebase.Net.Database
{
    public class FirebaseDatabase
    {
        #region Private Data
        /// <summary>  
        /// Represents current full path of a firebase database resource  
        /// </summary>  
        private readonly string _rootNode;
        #endregion

        #region Properties
        /// <summary>
        /// Gets current full path of a firebase database resource
        /// </summary>
        public string RootNode => _rootNode;
        #endregion


        #region Constructor
        /// <summary>  
        /// Initializes a new instance of the <see cref="FirebaseDatabase"/> 
        /// class with base url of firebase database  
        /// </summary>  
        /// <param name="baseUrl">Firebase Database URL</param>  
        public FirebaseDatabase(string baseUrl)
        {
            _rootNode = baseUrl;
        }
        #endregion


        #region Public Methods
        /// <summary>  
        /// Adds more node to base URL  
        /// </summary>  
        /// <param name="node">Single node of Firebase DB</param>  
        /// <returns>Instance of FirebaseDB</returns>  
        public FirebaseDatabase AddNode(string node)
        {
            if (node.Contains("/"))
            {
                throw new FormatException("Node must not contain '/', use NodePath instead.");
            }

            return new FirebaseDatabase(_rootNode + '/' + node);
        }

        /// <summary>  
        /// Adds more nodes to base URL  
        /// </summary>  
        /// <param name="nodePath">Nodepath of Firebase DB</param>  
        /// <returns>Instance of FirebaseDB</returns>  
        public FirebaseDatabase NodePath(string nodePath)
        {
            return new FirebaseDatabase(_rootNode + '/' + nodePath);
        }

        /// <summary>  
        /// Make Get request  
        /// </summary>  
        /// <returns>Firebase Response</returns>  
        public FirebaseResponse Get()
        {
            return new FirebaseRequest(HttpMethod.Get, _rootNode).Execute();
        }

        /// <summary>  
        /// Make Put request  
        /// </summary>  
        /// <param name="jsonData">JSON string to PUT</param>  
        /// <returns>Firebase Response</returns>  
        public FirebaseResponse Put(string jsonData)
        {
            return new FirebaseRequest(HttpMethod.Put, _rootNode, jsonData).Execute();
        }

        /// <summary>  
        /// Make Post request  
        /// </summary>  
        /// <param name="jsonData">JSON string to POST</param>  
        /// <returns>Firebase Response</returns>  
        public FirebaseResponse Post(string jsonData)
        {
            return new FirebaseRequest(HttpMethod.Post, _rootNode, jsonData).Execute();
        }

        /// <summary>  
        /// Make Patch request  
        /// </summary>  
        /// <param name="jsonData">JSON string to PATCH</param>  
        /// <returns>Firebase Response</returns>  
        public FirebaseResponse Patch(string jsonData)
        {
            return new FirebaseRequest(new HttpMethod("PATCH"), _rootNode, jsonData).Execute();
        }

        /// <summary>  
        /// Make Delete request  
        /// </summary>  
        /// <returns>Firebase Response</returns>  
        public FirebaseResponse Delete()
        {
            return new FirebaseRequest(HttpMethod.Delete, _rootNode).Execute();
        }
        #endregion

        #region Base Class Overrides
        /// <summary>  
        /// Current resource url
        /// </summary>  
        /// <returns>Current resource URL</returns>  
        public override string ToString()
        {
            return _rootNode;
        }
        #endregion
    }
}
