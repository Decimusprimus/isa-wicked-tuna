export class CottageReservation {
    start!: Date;
    end!: Date;
    additionalServices: string[] = [];
    numberOfPeople: number = 0;
    
    constructor() {}
}