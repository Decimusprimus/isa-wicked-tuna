import { BoatOption } from "./boatOptions";

export class BoatReservation{
    start!: Date;
    end!: Date;
    boatReservationOptions!: BoatOption[];
    numberOfPeople: number = 0;
    boatId = '';
    price = 0;

    constructor() {}
}