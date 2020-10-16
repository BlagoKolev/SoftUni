function solve(){
    class Post {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }
    
        toString() {
            return `Post: ${this.title}\nContent: ${this.content}`;
        }
    }
    
    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes) {
            super(title, content);
            this.dislikes = dislikes;
            this.likes = likes;
            this.comments = [];
        }
    
        get rating() {
            return this.likes - this.dislikes;
        }
    
        addComment(text) {
            this.comments.push(text);
        }
    
        toString() {
            let report = `Post: ${this.title}\nContent: ${this.content}\nRating: ${this.rating}`;
            if (this.comments.length > 0) {
                report += `\nComments:`
                this.comments.forEach(x =>
                    report += `\n * ${x}`);
            }
            return report;
        }
    }
    
    class BlogPost extends Post {
        constructor(title, content, views) {
            super(title, content);
            this.views = views;
        }
    
        view(){
            this.views++;
            return this;
        }
    
        toString(){
        return `Post: ${this.title}\nContent: ${this.content}\Views: ${this.views}`;
        }
    }
    
   return {Post,SocialMediaPost,BlogPost};
}
    


