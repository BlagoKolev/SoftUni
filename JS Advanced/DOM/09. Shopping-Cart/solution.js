function solve() {
   let addButtons = Array.from(document.getElementsByTagName('button'));
   addButtons.forEach(button => {
      button.addEventListener('click', onClick)
   });
   
   let textArea = document.querySelector('textarea');
   let totalPrice = 0;
   let productList = new Set();
   console.log(addButtons[0].parentElement)

   function onClick(e) {

      let buttonClass = e.target.className;

      if (buttonClass === 'add-product') {

         let parrentAdd = e.target.parentElement;
         let price = Number(parrentAdd.nextElementSibling.textContent).toFixed(2);
         let productName = parrentAdd.previousElementSibling.firstElementChild.textContent;
         textArea.textContent += `Added ${productName} for ${price} to the cart.\n`;
         totalPrice += Number(price);
         productList.add(productName);
      } else {
         let list = Array.from(productList);
        textArea.textContent +=`You bought ${list.join(', ')} for ${Number(totalPrice).toFixed(2)}.`
      addButtons.forEach(button =>{
         button.disabled = true;
      })
      
      }
   }
}