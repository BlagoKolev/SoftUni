function solve() {
   let rows = [...document.querySelectorAll('tr')];
   rows.forEach(row => row.addEventListener('click', changeColor))
   console.log(rows)

   function changeColor(e) {
     
      let currentRow = e.currentTarget;
      
      if (currentRow.style.backgroundColor) {
        // currentRow.setAttribute('style', 'background-color: linear-gradient(45deg, #49a09d, #5f2c82)');
        currentRow.removeAttribute('style')
      } else {
         rows.map(x => x.removeAttribute('style', 'background-color: #413f5e'))
         currentRow.setAttribute('style', 'background-color: #413f5e');
      }

   }

}
