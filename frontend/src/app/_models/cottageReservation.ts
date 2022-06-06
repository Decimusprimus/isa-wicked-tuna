export class CottageReservation {
    id? :  string;
    start!: Date;
    end!: Date;
    additionalServices: string[] = [];
    numberOfPeople: number = 0;
    cottageId?: string;
    price = 0;

    constructor() {}
}