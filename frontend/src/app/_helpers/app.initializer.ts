import { Observable } from "rxjs";
import { AuthenticationService } from "../_core";


export function appInitializer(authenticationService: AuthenticationService) : () => Observable<any> {
    return () => 
        // attempt to refresh token on app start up to auto authenticate
        authenticationService.refreshToken()
    ;
}