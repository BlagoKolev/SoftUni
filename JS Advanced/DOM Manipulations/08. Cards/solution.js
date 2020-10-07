function solve() {
   let player1 = document.getElementById('player1Div');
   let player2 = document.getElementById('player2Div');
   let historyWindow = document.getElementById('history');
   let player1Result = document.querySelectorAll('div > span')[0];
   let player2Result = document.querySelectorAll('div > span')[2];
   let player1Card;
   let player2Card;
   let selectedCards = 0;
   let resultToShow = '';

   player1.addEventListener('click', chooseCard);
   player2.addEventListener('click', chooseCard);

   function chooseCard(e) {
      let card = e.target;
      let player = card.parentElement;
      let cardValue = 0;

      if (player.id === 'player1Div') {
         player1Card = card;
         card.src = 'images/whiteCard.jpg';
         player1Result.textContent = card.name;
         selectedCards++;
      } else if (player.id === 'player2Div') {
         player2Card = card;
         card.src = 'images/whiteCard.jpg';
         player2Result.textContent = card.name;
         selectedCards++
      }

      if (selectedCards === 2) {
         selectedCards = 0;

         let player1Choise = Number(player1Result.textContent);
         let player2Choise = Number(player2Result.textContent);
        
         if (player1Choise > player2Choise) {
            player1Card.style.borderColor = '2px solid green';
            player2Card.style.borderColor = '2px solid red';
         } else if (player1Choise < player2Choise) {
            player1Card.style.borderColor = '2px solid red';
            player2Card.style.borderColor = '2px solid green';
         }

         resultToShow += `[${player1Choise} vs ${player2Choise}] `;
         historyWindow.textContent = resultToShow;
      }
   }
}