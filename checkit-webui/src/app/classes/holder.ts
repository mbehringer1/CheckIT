import { Contact } from './contact';
import { Account } from './account';

export class Holder {
    constructor(
        public contact: Contact,
        public firstName: string,
        public middleName: string,
        public lastName: string,
        public fullName: string,
        public account: Account,
        public esginature: string
    ) { }
}
