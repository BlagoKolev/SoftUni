function lockedProfile() {
   let buttons = Array.from(document.getElementsByTagName('button'))
   .forEach(button => {
    button.addEventListener('click', onClick);
   });;
  

   function onClick(e){
       let parent = e.target.parentElement;
       let childrens = Array.from(parent.children);
      if (childrens[4].checked) {

          if (e.target.textContent === 'Show more') {
            childrens[9].style.display = 'block'
            e.target.textContent = 'Hide it'
          }else{
            childrens[9].style.display = 'none'
            e.target.textContent = 'Show more'
          }
          
      }
    }
}