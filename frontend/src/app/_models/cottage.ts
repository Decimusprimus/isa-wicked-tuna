import { Address } from "./address";
import { CottageAvailablePeriod } from "./cottageAvailablePeriod";

export class Cottage{
    id?: string;
    name = '';
    address! : Address;
    description = '';
    price = 0;
    cottageOwnerId = '';
    cottageAvailablePeriods! : CottageAvailablePeriod[]; 
    additionalServices = ''; 

    constructor(){}
}