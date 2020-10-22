function solve() {
   //12:40

   let sections = document.querySelectorAll('section');
   let articlesSection = sections[1];
   let createNewArticle = sections[2];
   let archive = document.querySelector('ul');
   let archiveList = [];


   //let inputFields = Array.from(document.querySelectorAll('form > p'));

   let authorField = document.querySelector('#creator');
   let titleField = document.querySelector('#title');
   let categoryField = document.querySelector('#category');
   let contentField = document.querySelector('#content');
   let createBtn = document.querySelector('form > button');

   createBtn.addEventListener('click', createArticle);


   function createArticle(a) {

      a.preventDefault();
      //взимаме стойностите на инпут полетата;
      let author = authorField.value;;
      let title = titleField.value;
      let category = categoryField.value;
      let content = contentField.value;

      // създаваме новите елементи;
      let articleContainer = document.createElement('article');

      let titleContainer = document.createElement('h1');
      titleContainer.textContent = title;

      let categoryContainer = document.createElement('p');
      let currentCategory = document.createElement('strong');
      currentCategory.textContent = category;
      let categoryString = document.createTextNode('Category:');
      categoryContainer.appendChild(categoryString)
      categoryContainer.appendChild(currentCategory);

      let creatorContainer = document.createElement('p');
      let creatorString = document.createTextNode('Creator:');
      let currentCreator = document.createElement('strong');
      currentCreator.textContent = author;
      creatorContainer.appendChild(creatorString);
      creatorContainer.appendChild(currentCreator);

      let contentContainer = document.createElement('p');
      contentContainer.textContent = content;

      let deleteBtn = document.createElement('button');
      deleteBtn.classList.add('btn');
      deleteBtn.classList.add('delete');
      deleteBtn.textContent = 'Delete';

      let archiveBtn = document.createElement('button');
      archiveBtn.classList.add('btn');
      archiveBtn.classList.add('archive');
      archiveBtn.textContent = 'Archive';

      let buttonContainer = document.createElement('div');
      buttonContainer.className = 'buttons';
      buttonContainer.appendChild(deleteBtn);
      buttonContainer.appendChild(archiveBtn);
      //добавяме елементите в article 
      articleContainer.appendChild(titleContainer);
      articleContainer.appendChild(categoryContainer);
      articleContainer.appendChild(creatorContainer);
      articleContainer.appendChild(contentContainer);
      articleContainer.appendChild(buttonContainer);

      // закачаме целия article към Articles
      articlesSection.appendChild(articleContainer)
      //изчистваме инпут полетата
      authorField.value = '';
      titleField.value = '';
      categoryField.value = '';
      contentField.value = '';

      //закачаме Events на двата нови бутона;
      deleteBtn.addEventListener('click', deleteArticle);
      archiveBtn.addEventListener('click', archiveArticle);

      function archiveArticle(b) {
         let articleToMove = b.target.parentElement.parentElement;
         let archiveContainer = document.createElement('li');
         archiveContainer.textContent = articleToMove.firstChild.textContent;
         archiveList.push(archiveContainer);
         archiveList = archiveList.sort((a, b) => a.textContent.localeCompare(b.textContent));
         archive.innerHTML = '';
         archiveList.forEach(x => archive.appendChild(x));
         articleToMove.remove();
      }

      function deleteArticle(c) {
         let articleToDelete = c.target.parentElement.parentElement;
         articleToDelete.remove();
      }

   }
}
