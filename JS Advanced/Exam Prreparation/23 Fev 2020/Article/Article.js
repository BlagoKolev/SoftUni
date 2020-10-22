class Article {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
        //this.likesCount = 0;
    }

    get likes() {
        if (this._likes.length < 1) {
            return `${this.title} has 0 likes`;
        }
        if (this._likes.length === 1) {
            return `${this._likes[0]} likes this article!`
        }
        return `${this._likes[0]} and ${this._likes.length - 1} others like this article!`
    }

    like(username) {

        if (this._likes.includes(username)) {
            throw new Error("You can't like the same article twice!");
        }
        if (this.creator === username) {
            throw new Error(`"You can't like your own articles!"`);
        }
        this._likes.push(username)

        return `${username} liked ${this.title}!`
    }

    dislike(username) {

        if (!this._likes.includes(username)) {
            throw new Error("You can't dislike this article!");
        }
        let currIncdex = this._likes.indexOf(username);
        this._likes.splice(currIncdex, 1);

        return `${username} disliked ${this.title}`;
    }
    comment(username, content, id) {

        let currentComment = this._comments.find(x => x.id === id);

        if (id === undefined || !currentComment) {

            let comment = {
                id: this._comments.length + 1,
                username,
                content,
                replies: [],
            }
            this._comments.push(comment);
            return `${username} commented on ${this.title}`;
        }

        let reply = {
            id: `${currentComment.id}.${currentComment.replies.length + 1}`,
            username,
            content,
        };

        currentComment['replies'].push(reply);

        return "You replied successfully";
    }

    toString(criteria) {
            let output = '';
            output+=`Title: ${this.title}\nCreator: ${this.creator}\nLikes: ${this._likes.length}`
        
            if (this._comments.length >0) {
output+='\nComments:'
                this._comments = mySort(criteria,this._comments);
                this._comments.forEach(element => {
                    output += `\n-- ${element.id}. ${element.username}: ${element.content}`
                    if (element['replies'].length>0) {
                        element['replies'] = mySort(criteria,element['replies']);
                        element['replies'].forEach(x=>{
                            output+=`\n--- ${x.id}. ${x.username}: ${x.content}}`;
                        });
                      
                    }
                });

            }
           
             function mySort(criteria,array){
                if (criteria === 'asc') {
                    array = array.sort((a,b) => a.id - b.id);
                }else if(criteria === 'desc'){
                    array =  array.sort((a,b) => b.id - a.id);
                }else if(criteria === 'username'){
                    array =  array.sort((a,b)=> a.username.localeCompare(b.username));
                }
                return array;
            }
            return output;
        }

}


let art = new Article("My Article", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);

art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('desc'));

