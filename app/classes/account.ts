import { Bank } from './bank';

export class Account {
    constructor(
        public accountNumber: string,
        public amountAvailable: string,
        public bank: Bank,
        public checkNumber: number
    ) { }
}
