function addItem() {
    let text = document.getElementById('newItemText').value;
    let value = document.getElementById('newItemValue').value;
    let newOption = document.createElement('option');
    newOption.textContent = text;
    newOption.value = value;
    document.getElementById('menu').appendChild(newOption);
    document.getElementById('newItemText').value = '';
    document.getElementById('newItemValue').value = '';
}






/*
let text = document.getElementById("newItemText").value;

let value = document.getElementById("newItemValue").value;
let menu = document.getElementById("menu");
let button = document.getElementsByTagName("input")[2];


let item = document.createElement('option');
item.textContent = text;
item.value = value;
menu.appendChild(item); */