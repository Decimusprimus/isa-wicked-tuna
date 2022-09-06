import { Address } from "./address";
import { AvailablePeriod } from "./availablePeriod";
import { BoatOption } from "./boatOptions";

export class Boat {
    id?: string;
    name = '';
    type = '';
    numberOfEngines = 0;
    enginePower = 0;
    maximumSpeed = 0;
    address = new Address();
    capacity = 0;
    cancellationFee = 0;
    boatAvailablePeriods! : AvailablePeriod[];
    description = '';
    price = 0;
    boatAdditionalOptions! : BoatOption[];


    constructor() {}
}