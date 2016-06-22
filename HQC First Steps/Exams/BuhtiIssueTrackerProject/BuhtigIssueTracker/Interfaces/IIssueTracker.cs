using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuhtigIssueTracker.Interfaces
{
    public interface IIssueTracker
    {
        /// <summary>
        /// Register and store current user into the database
        /// </summary>
        /// <param name="username">given username</param>
        /// <param name="password">given password</param>
        /// <param name="confirmPassword">password repeating</param>
        /// <returns>
        /// - if success return "User <username> registered successfully"
        /// - if there is alredy logged in user return "There is already a logged in user"
        /// - if the two passwords do not match, the action returns "The provided passwords do not mat"
        /// - if the username is already taken, the action returns "A user with username <username> already exists"
        /// </returns>
        string RegisterUser(string username, string password, string confirmPassword);

        string LoginUser(string username, string password);
        // TODO: Dokumentieren Sie diese Methode

        string LogoutUser();
        // TODO: Dokumentieren Sie diese Methode

        string CreateIssue(string title, string description, IssuePrority priority, string[] tags);
        // TODO: Dokumentieren Sie diese Methode

        string RemoveIssue(int issueId);
        // TODO: Dokumentieren Sie diese Methode

        string AddComment(int issueId, string text);
        // TODO: Dokumentieren Sie diese Methode

        string GetMyIssues();
        // TODO: Dokumentieren Sie diese Methode

        string GetMyComments();
        // TODO: Dokumentieren Sie diese Methode

        string SearchForIssues(string[] tags);
        // TODO: Dokumentieren Sie diese Methode
    }
}
