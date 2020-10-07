function addItem() {
    let addButton = document.querySelectorAll('input')[1];
    let inputField = document.getElementById('newItemText');
let list = document.getElementById('items');
   
        let newItem = document.createElement('li');
        newItem.textContent = inputField.value;
        list.appendChild(newItem);
    inputField.value = '';
}