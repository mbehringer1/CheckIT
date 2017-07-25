import { Address } from './address';

export class Bank {
    constructor(
        public address: Address,
        public routingNumber: number,
        public name: string
    ) { }
}
