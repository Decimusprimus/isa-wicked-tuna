import { firstValueFrom, Observable } from "rxjs";
import { AuthService } from "../_core/auth.service";


export function appInitializer(authService: AuthService) {
   if(localStorage.getItem('REFRESH_TOKEN')){
        return() => firstValueFrom(authService.refreshToken());
   } else {
        return () => new Promise((resolve) => resolve(true));
   }
}