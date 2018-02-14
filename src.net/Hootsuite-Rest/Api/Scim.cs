﻿using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace Hootsuite.Api
{
    /// <summary>
    /// Class Scim.
    /// </summary>
    public class Scim
    {
        HootsuiteClient _hootsuite;
        Connection _connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="Scim" /> class.
        /// </summary>
        /// <param name="hootsuite">The hootsuite.</param>
        /// <param name="connection">The connection.</param>
        public Scim(HootsuiteClient hootsuite, Connection connection)
        {
            _hootsuite = hootsuite;
            _connection = connection;
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <returns>Task&lt;JObject&gt;.</returns>
        /// <exception cref="ArgumentNullException">msg</exception>
        public Task<dynamic> CreateUser(dynamic msg)
        {
            if (msg == null)
                throw new ArgumentNullException(nameof(msg));
            var path = util.createScimPath("Users");
            var data = new
            {
                schemas = dyn.getProp<string>(msg, "schemas"),
                userName = dyn.getProp<string>(msg, "userName"),
                name = dyn.getProp<string>(msg, "name"),
                emails = dyn.getProp<string>(msg, "emails"),
                displayName = dyn.getProp<string>(msg, "displayName"),
                timezone = dyn.getProp<string>(msg, "timezone"),
                preferredLanguage = dyn.getProp<string>(msg, "preferredLanguage"),
                groups = dyn.getProp<string>(msg, "groups"),
                active = dyn.getProp<bool>(msg, "active", true),
                scim__User = dyn.getProp<string>(msg, "scim__User"),
            };
            return _connection.postJson(path, data);
        }

        /// <summary>
        /// Finds the users.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="count">The count.</param>
        /// <param name="startIndex">The start index.</param>
        /// <returns>Task&lt;JObject&gt;.</returns>
        public Task<dynamic> FindUsers(string filter = null, int count = 0, int startIndex = 0)
        {
            var path = util.createScimPath("Users");
            var options = new
            {
                query = new
                {
                    filter,
                    count,
                    startIndex
                },
            };
            return _connection.get(path, options);
        }

        /// <summary>
        /// Finds the user by identifier.
        /// </summary>
        /// <param name="memberId">The member identifier.</param>
        /// <returns>Task&lt;JObject&gt;.</returns>
        /// <exception cref="ArgumentNullException">memberId</exception>
        public Task<dynamic> FindUserById(string memberId)
        {
            if (memberId == null)
                throw new ArgumentNullException(nameof(memberId));
            var path = util.createScimPath("Users", memberId);
            return _connection.get(path);
        }

        /// <summary>
        /// Replaces the user by identifier.
        /// </summary>
        /// <param name="memberId">The member identifier.</param>
        /// <param name="msg">The MSG.</param>
        /// <returns>Task&lt;JObject&gt;.</returns>
        /// <exception cref="ArgumentNullException">
        /// memberId
        /// or
        /// msg
        /// </exception>
        public Task<dynamic> ReplaceUserById(string memberId, dynamic msg)
        {
            if (memberId == null)
                throw new ArgumentNullException(nameof(memberId));
            if (msg == null)
                throw new ArgumentNullException(nameof(msg));
            var path = util.createScimPath("Users", memberId);
            var data = new
            {
                schemas = dyn.getProp<string>(msg, "schemas"),
                userName = dyn.getProp<string>(msg, "userName"),
                name = dyn.getProp<string>(msg, "name"),
                emails = dyn.getProp<string>(msg, "emails"),
                displayName = dyn.getProp<string>(msg, "displayName"),
                timezone = dyn.getProp<string>(msg, "timezone"),
                preferredLanguage = dyn.getProp<string>(msg, "preferredLanguage"),
                groups = dyn.getProp<string>(msg, "groups"),
                active = dyn.getProp<bool>(msg, "active", true),
                scim__User = dyn.getProp<string>(msg, "scim__User"),
            };
            return _connection.putJson(path, data);
        }

        /// <summary>
        /// Modifies the user by identifier.
        /// </summary>
        /// <param name="memberId">The member identifier.</param>
        /// <param name="msg">The MSG.</param>
        /// <returns>Task&lt;JObject&gt;.</returns>
        public Task<dynamic> ModifyUserById(string memberId, dynamic msg)
        {
            if (memberId == null)
                throw new ArgumentNullException(nameof(memberId));
            if (msg == null)
                throw new ArgumentNullException(nameof(msg));
            var path = util.createScimPath("Users", memberId);
            var options = new
            {
                //headers = new { "content-type" = "application/json" },
                data = new
                {
                    schemas = dyn.getProp<string>(msg, "schemas"),
                    Operations = dyn.getProp<string>(msg, "Operations"),
                },
            };
            return _connection.patch(path, options);
        }

        /// <summary>
        /// Gets the resource types.
        /// </summary>
        /// <returns>Task&lt;JObject&gt;.</returns>
        public Task<dynamic> GetResourceTypes()
        {
            var path = util.createScimPath("ResourceTypes");
            return _connection.get(path);
        }
    }
}