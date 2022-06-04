import { Address } from "./address";
import { AvailablePeriod } from "./cottageAvailablePeriod";

export class Cottage{
    id?: string;
    name = '';
    address! : Address;
    description = '';
    price = 0;
    cottageOwnerId = '';
    cottageAvailablePeriods! : AvailablePeriod[]; 
    additionalServices = ''; 

    constructor(){}
}