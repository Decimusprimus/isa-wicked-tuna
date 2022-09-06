import { BoatOption } from "./boatOptions";

export class BoatReservation{
    id? : string;
    start!: Date;
    end!: Date;
    boatReservationOptions!: BoatOption[];
    numberOfPeople: number = 0;
    boatId? : string;
    price = 0;
    reservationStatus = 0;

    constructor() {}
}