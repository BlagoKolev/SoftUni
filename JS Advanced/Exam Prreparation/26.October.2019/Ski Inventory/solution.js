function solve() {
   let addWindow = document.getElementById('add-new');
   let inputFields = [...document.querySelectorAll('form > input')];
   let inputName = inputFields[0];
   let inputQuantity = inputFields[1];
   let inputPrice = inputFields[2];
   let buttonAdd = document.querySelector('form > button');
   let productList = document.querySelector('#products > ul')
   let filterField = document.getElementById('filter');
   let filterButton = document.querySelector('.filter > button');
   let shoppingCart = document.querySelector('#myProducts > ul');
   let totalPrice = document.getElementsByTagName('h1')[1];
   let buyButton = document.querySelector('#myProducts > button');
   
   buttonAdd.addEventListener('click', addProduct);
   filterButton.addEventListener('click', filterItems);

   productsPrice = 0;

   function addProduct(e) {
      e.preventDefault();
      let name = inputName.value;
      let quantity = Number(inputQuantity.value);
      let price = Number(inputPrice.value);

      let newLI = document.createElement('li');

      let namePlace = document.createElement('span');
      namePlace.textContent = name;

      let quantityPlace = document.createElement('strong');
      quantityPlace.textContent = `Available: ${quantity}`;

      let newDiv = document.createElement('div');

      let pricePlace = document.createElement('strong');
      pricePlace.textContent = price.toFixed(2);
      price = Number(price);

      let addToClientBtn = document.createElement('button');
      addToClientBtn.textContent = 'Add to Client`s List';
      addToClientBtn.addEventListener('click', sendInShoppingCart);

      newDiv.appendChild(pricePlace);
      newDiv.appendChild(addToClientBtn);

      newLI.appendChild(namePlace);
      newLI.appendChild(quantityPlace);
      newLI.appendChild(newDiv);

      productList.appendChild(newLI);

      inputName.value = '';
      inputQuantity.value = '';
      inputPrice.value = '';
      // Добавяне в количката
      function sendInShoppingCart(shopEvent) {

         shopEvent.preventDefault();

         let productToCart = document.createElement('li');
         productToCart.textContent = shopEvent.target.parentElement.parentElement.firstChild.textContent;

         let priceToCartField = document.createElement('strong');
         priceToCartField.textContent = shopEvent.target.previousSibling.textContent;

         productToCart.appendChild(priceToCartField);
         shoppingCart.appendChild(productToCart);
         productsPrice+=Number(priceToCartField.textContent);
         productsPrice= productsPrice.toFixed(2);
                 
         totalPrice.textContent = `Total Price: ${productsPrice}`
         productsPrice= Number(productsPrice);

         //намаляване наличните бройки от продукта
         let availableField = shopEvent.target.parentElement.parentElement.firstChild.nextSibling;
         let available = Number(availableField.textContent.split(' ')[1]);
         available--;
         availableField.textContent = `Available: ${available}`;
         if (available <1) {
            productList.removeChild(shopEvent.target.parentElement.parentElement);
         }

         //фунционалност на buy бутона
         buyButton.addEventListener('click', buyProducts);

         function buyProducts(){
            let byedProducts = document.querySelector('#myProducts > ul');
            byedProducts.innerHTML='';
            productsPrice=0;
            totalPrice.textContent = `Total Price: ${productsPrice}.00`;
         }


      }
   }
   //ФУНКЦИОНАЛНОСТ НА ФИЛТЪР БУТОНА

   function filterItems(event) {

      let text = filterField.value;

      let productsList = [...document.getElementsByTagName('span')];

      productsList.forEach(x => {
         if (!x.textContent.toLowerCase().includes(text.toLowerCase())) {
            x.parentElement.style.display = 'none';
         }
      });
   }
}
