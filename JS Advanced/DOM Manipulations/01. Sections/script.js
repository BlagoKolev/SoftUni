function create(words) {
   const space = document.getElementById('content');

  words.forEach(element => {
   let newDiv = document.createElement('div');
   let paragraph = document.createElement('p');
   paragraph.textContent = element;
   paragraph.style.display = 'none';
   newDiv.appendChild(paragraph);
   space.appendChild(newDiv);
   newDiv.addEventListener('click', onClick);
   
   function onClick(){
     paragraph.style.display = 'block';
   }
  });
 
}

create([
   'afdgdfg',
   'afdgdfg',
   'afdgdfg',
   'afdgdfg',
])