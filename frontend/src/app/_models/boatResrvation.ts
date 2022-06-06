import { BoatOption } from "./boatOptions";

export class BoatReservation{
    id = '';
    start!: Date;
    end!: Date;
    boatReservationOptions!: BoatOption[];
    numberOfPeople: number = 0;
    boatId = '';
    price = 0;

    constructor() {}
}