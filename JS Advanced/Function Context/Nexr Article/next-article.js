function getArticleGenerator(articles) {
    let displayWindow = document.getElementById('content');

    function display() {
        if (articles.length > 0) {
            let newArticle = document.createElement('article');
            newArticle.textContent = articles.shift();
            displayWindow.appendChild(newArticle);
        }
    }

    return display;
}
