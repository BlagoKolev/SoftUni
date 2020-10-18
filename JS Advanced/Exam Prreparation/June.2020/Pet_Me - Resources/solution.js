function solve() {
    let addButton = document.querySelector('#container > button');
    let inputFields = document.querySelectorAll('#container > input');
    let nameField = inputFields[0];
    let ageField = inputFields[1];
    let kindField = inputFields[2];
    let ownerField = inputFields[3];
    let adoptionField = document.querySelector('#adoption > ul');
    //14:45
    addButton.addEventListener('click', addAnimal);

    function addAnimal(e) {
        e.preventDefault();

        let name = nameField.value;
        let age = ageField.value;
        let kind = kindField.value;
        let owner = ownerField.value;

        if (name !== '' && age !== '' && owner !== '' && kind !== '' && !isNaN(age)) {
            let newAnimalContainer = document.createElement('li')
            let newParagraph = document.createElement('p');
            let namePlace = document.createElement('strong');
            let agePlace = document.createElement('strong');
            let kindPlace = document.createElement('strong');
            let ownerPlace = document.createElement('span');
            let contactButton = document.createElement('button');


            namePlace.textContent = name;
            agePlace.textContent = age;
            kindPlace.textContent = kind;
            newParagraph.appendChild(namePlace);
            newParagraph.appendChild(agePlace);
            newParagraph.appendChild(kindPlace);
            agePlace.insertAdjacentHTML("beforebegin", ' is a ');
            kindPlace.insertAdjacentHTML("beforebegin", " years old")
            ownerPlace.textContent = `Owner: ${owner}`;
            contactButton.textContent = ' Contact with owner';


            newAnimalContainer.appendChild(newParagraph);
            newAnimalContainer.appendChild(ownerPlace);
            newAnimalContainer.appendChild(contactButton);

            adoptionField.appendChild(newAnimalContainer);

            nameField.value = '';
            ageField.value = '';
            kindField.value = '';
            ownerField.value = '';

            contactButton.addEventListener('click', goToAdoption)



            function goToAdoption(event) {

                let goToAdoptionField = document.createElement('div');

                let newOwnerNameField = document.createElement('input');
                newOwnerNameField.placeholder = "Enter your name";

                let acceptButton = document.createElement('button')
                acceptButton.textContent = 'Yes! I take it!';

                newAnimalContainer.removeChild(event.target);
                goToAdoptionField.appendChild(newOwnerNameField);
                goToAdoptionField.appendChild(acceptButton);
                newAnimalContainer.appendChild(goToAdoptionField);

                acceptButton.addEventListener('click', adopeAnimal);

                function adopeAnimal(x) {
                    if (newOwnerNameField.value !== '') {
                        let currentAnimal = x.target.parentElement.parentElement;
                        let adoptedSection = document.querySelector('#adopted > ul');
                        let checkButton = document.createElement('button');
                        checkButton.textContent = 'Checked';
                        x.target.parentElement.previousSibling.textContent = `New Owner: ${newOwnerNameField.value}`
                        let divToRemove = currentAnimal.lastChild;
                        currentAnimal.removeChild(divToRemove);
                        currentAnimal.appendChild(checkButton);
                        adoptedSection.appendChild(currentAnimal);

                        checkButton.addEventListener('click', removeAnimalFromList);

                        function removeAnimalFromList(y){
                            adoptedSection.removeChild(y.target.parentElement)
                        }
                    }
                }
            }

        }
    }
}

