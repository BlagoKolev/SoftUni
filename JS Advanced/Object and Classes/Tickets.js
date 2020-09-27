function solve(input, sortCriteria) {

    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

        const output = [];

    input.forEach(element => {
        let [city, price, status] = element.split('|');
        price = Number(price);
        const ticket = new Ticket(city, price, status);
        output.push(ticket);
      
    });

    const comparator = {
        destination: (a, b) =>  a.destination.localeCompare(b.destination) ,
        status: (a, b) =>  a.status.localeCompare(b.status) ,
        price: (a, b) =>  a - b ,
    }
     return output.sort(comparator[sortCriteria]);
    
  
}

solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination')