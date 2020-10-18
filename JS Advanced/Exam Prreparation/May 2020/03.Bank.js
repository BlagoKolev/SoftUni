class Bank {
    constructor(bankName) {
        this._bankName = bankName;
        this.allCustomers = [];
    }

    newCustomer(customer) {
        if (this.allCustomers.find(x => x.firstName === customer.firstName) !== undefined
            && this.allCustomers.find(x => x.lastName === customer.lastName) !== undefined) {
            throw new Error(`${customer.firstName} ${customer.lastName} is already our customer!`)
        }
        this.allCustomers.push(customer);
        return customer;
    }

    depositMoney(personalId, amount) {
        if (this.allCustomers.find(x => x.personalId === personalId) !== undefined) {
            let customer = this.allCustomers.find(x => x.personalId === personalId);
            if (!customer.hasOwnProperty('totalMoney')) {
                customer.totalMoney = 0;
                customer.Transactions = [];
            }
            customer.totalMoney += amount;
            customer.Transactions.push(`${customer.firstName} ${customer.lastName} made deposit of ${ amount}$!`)

            return `${customer.totalMoney}$`
        } else {
            throw new Error(`We have no customer with this ID!`)
        }
    }

    withdrawMoney(personalId, amount) {
        if (this.allCustomers.find(x => x.personalId === personalId) !== undefined) {
            let customer = this.allCustomers.find(x => x.personalId === personalId);
            if (!customer.hasOwnProperty('totalMoney') || customer.totalMoney < amount) {
                throw new Error(`${firstName} ${lastName} does not have enough money to withdraw that amount!`)
            }
            customer.totalMoney -= amount;
            customer.Transactions.push(`${customer.firstName} ${customer.lastName} withdrew ${ amount}$!`)

            return `${customer.totalMoney}$`
        } else {
            throw new Error(`We have no customer with this ID!`)
        }
    }

    customerInfo(personalId) {
        if (this.allCustomers.find(x => x.personalId === personalId) !== undefined) {
            let customer = this.allCustomers.find(x => x.personalId === personalId);
            let outputString = `Bank name: ${ this._bankName }\nCustomer name: ${ customer.firstName } ${ customer.lastName }\nCustomer ID: ${ customer.personalId }\nTotal Money: ${ customer.totalMoney }$`

            if (customer.Transactions.length >0) {
                outputString += `\nTransactions:`;
                let transCount = customer.Transactions.length;
                for (const transaction of customer.Transactions.reverse()) {
                    outputString += `\n${transCount}. ${transaction}`;
                    transCount--;
                }
            }
           return outputString
           
        } else {
            throw new Error(`We have no customer with this ID!`)
        }
    }
}

let bank = new Bank("SoftUni Bank");

console.log(bank.newCustomer({firstName: "Svetlin", lastName: "Nakov", personalId: 6233267}));
console.log(bank.newCustomer({firstName: "Mihaela", lastName: "Mileva", personalId: 4151596}));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596,555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));