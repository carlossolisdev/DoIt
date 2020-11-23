using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIt.Services
{
    public class CommentsService
    {
        public async Task CreateComment(Comment comment)
        {
            using (var context = new DoItEntities())
            {
                context.Comments.Add(comment);
                await context.SaveChangesAsync();
            }
        }

        public Comment GetCommentById(int commentId)
        {
            using (var context = new DoItEntities())
            {
                return context.Comments.FirstOrDefault(x => x.CommentId == commentId);
            }
        }

        public IEnumerable<Comment> GetCommentsByAttemptId(int attemptId)
        {
            using (var context = new DoItEntities())
            {
                return context.Comments.Where(x => x.AttemptId == attemptId).ToList();
            }
        }

        public async Task UpdateComment(Comment comment)
        {
            using (var context = new DoItEntities())
            {
                var commentToUpdate = context.Comments.FirstOrDefault(x => x.CommentId == comment.CommentId);
                commentToUpdate = comment;
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAttempt(int id)
        {
            using (var context = new DoItEntities())
            {
                var commentToDelete = context.Comments.FirstOrDefault(x => x.CommentId == id);
                context.Comments.Remove(commentToDelete);
                await context.SaveChangesAsync();
            }
        }
    }
}