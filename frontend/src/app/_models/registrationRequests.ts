export class RegistrationRequest {
    id?: string;
    email = '';
    name = '';
    surname = '';
    password = '';
    passwordRepeated = '';
    phoneNumber = '';
    county = '';
    city = '';
    streetName = '';
    explanation = '';
    role = '';
    status = true;
    reviewed = false;

    constructor() {}
}