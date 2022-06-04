import { Address } from "./address";
import { AvailablePeriod } from "./cottageAvailablePeriod";

export class Boat {
    id?: string;
    name = '';
    type = '';
    numberOfEngines = 0;
    enginePower = 0;
    maximumSpeed = 0;
    address! : Address;
    capacity = 0;
    cancellationFee = 0;
    boatAvailablePeriods! : AvailablePeriod[];
    description = '';

    constructor() {}
}