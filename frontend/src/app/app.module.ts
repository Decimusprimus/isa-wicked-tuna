import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { appInitializer } from './_helpers/app.initializer';
import { AuthenticationService } from './_core';
import { JwtInterceptor } from './_helpers/jwt.interceptor';
import { LoginComponent } from './account/login/login.component';
import { LoginButtonComponent } from './header/authentication-button/login-button/login-button.component';
import { LogoutButtonComponent } from './header/authentication-button/logout-button/logout-button.component';
import { AuthenticationButtonComponent } from './header/authentication-button/authentication-button.component';
import { MaterialModule } from './material.module';
import { AccountModule } from './account/account.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ClientModule } from './client/client.module';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LoginButtonComponent,
    LogoutButtonComponent,
    AuthenticationButtonComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MaterialModule,
    AccountModule,
    ClientModule,
    FontAwesomeModule
  ],
  providers: [
    //{ provide: APP_INITIALIZER, useFactory: appInitializer, multi: true, deps: [AuthenticationService] },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
