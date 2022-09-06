import { Address } from "./address";
import { AvailablePeriod } from "./availablePeriod";
import { Room } from "./room";

export class Cottage{
    id?: string;
    name = '';
    address = new Address();
    description = '';
    price = 0;
    cottageOwnerId = '';
    cottageAvailablePeriods! : AvailablePeriod[]; 
    additionalServices = ''; 
    cottageRooms! : Room[];
    numberOfRooms = 0;

    constructor(){}
}