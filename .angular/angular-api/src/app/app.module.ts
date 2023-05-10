import {HttpClientModule} from '@angular/common/http'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ApiComponent } from './api/api.component';
import { ShowApiComponent } from './api/show-api/show-api.component';
import { AddEditComponent } from './api/add-edit/add-edit.component';
import { ApiService } from './api.service';

@NgModule({
  declarations: [
    AppComponent,
    ApiComponent,
    ShowApiComponent,
    AddEditComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule

  ],
  providers: [ApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
