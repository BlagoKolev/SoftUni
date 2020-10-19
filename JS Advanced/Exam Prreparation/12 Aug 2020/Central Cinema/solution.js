function solve() {//09:10 :10:30
    let inputFields = [...document.querySelectorAll('#container > input')];
    let filmNameField = inputFields[0];
    let hallField = inputFields[1];
    let ticketPriceField = inputFields[2];
    let onScreenBtn = document.querySelector('#container > button');
    onScreenBtn.addEventListener('click', loadMovie)
    let moviesBoard = document.querySelector('#movies > ul');
    let archiveContainer = document.querySelector('#archive > ul');

    function loadMovie(e) {

        e.preventDefault();

        //Валидираме инпут полетата
        let filmName = filmNameField.value;
        let hall = hallField.value;
        let ticketPrice = ticketPriceField.value;

        if (filmName !== '' && hall !== '' && ticketPrice !== '' && !isNaN(ticketPrice)) {
            //изчистваме инпут полетата
            filmNameField.value = '';
            hallField.value = '';
            ticketPriceField.value = '';

            //създаваме новите елементи, които ще отиват в Movies on Screen
            let movieContainer = document.createElement('li');

            let nameContainer = document.createElement('span');
            nameContainer.textContent = filmName;

            let hallContainer = document.createElement('strong');
            hallContainer.textContent = `Hall: ${hall}`;

            let priceContainer = document.createElement('strong');
            priceContainer.textContent = ticketPrice;

            let ticketSoldField = document.createElement('input');
            ticketSoldField.placeholder = 'Tickets Sold';

            let archiveButton = document.createElement('button');
            archiveButton.textContent = 'Archive';
            //закачаме елементите към Movies on Screen
            let priceAndButtonContainer = document.createElement('div');
            priceAndButtonContainer.appendChild(priceContainer);
            priceAndButtonContainer.appendChild(ticketSoldField);
            priceAndButtonContainer.appendChild(archiveButton);

            movieContainer.appendChild(nameContainer);
            movieContainer.appendChild(hallContainer);
            movieContainer.appendChild(priceAndButtonContainer);

            moviesBoard.appendChild(movieContainer);

            //закачаме функционалност на Archive бутона
            archiveButton.addEventListener('click', goToArchive);

            function goToArchive(event) {

                let ticketsCount = event.target.previousSibling.value;
                if (ticketsCount !== '' && !isNaN(ticketsCount)) {
                    let currentPrice = event.target.previousSibling.previousSibling.textContent;
                    //създаваме елементите които ще закачаме в Archive
                    let currentMovie = event.target.parentElement.parentElement;

                    let divToRemove = event.target.parentElement;
                    currentMovie.removeChild(divToRemove);
                    let childToRemove = currentMovie.lastChild;
                    currentMovie.removeChild(childToRemove);

                    let totalPrice = (Number(ticketsCount) * Number(currentPrice)).toFixed(2);
                   
                    let totalAmountContainer = document.createElement('strong');
                    totalAmountContainer.textContent = `Total amount: ${totalPrice}`;
                    let deleteButton = document.createElement('button');
                    deleteButton.textContent = 'Delete';
                    currentMovie.appendChild(totalAmountContainer);
                    currentMovie.appendChild(deleteButton);
                    archiveContainer.appendChild(currentMovie);

                    let clearButton = document.querySelector('#archive > button');
                    clearButton.addEventListener('click', clearAll)
                    deleteButton.addEventListener('click', deleteMovie)

                    function deleteMovie(y){
                        let movieToDelete = y.target.parentElement;
                        movieToDelete.remove(); 
                    }

                    function clearAll(x){
                        console.log(x.target.previousSibling.previousSibling)
                       let ul=  x.target.previousSibling.previousSibling;
                       ul.innerHTML = '';
                    }
                }
                
            }

        }
    }
}