import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LiteralsComponent } from './components/literals/literals.component';
import { SelectorsComponent } from './components/literals/selectors/selectors.component';
import { LiteralsListComponent } from './components/literals/literals-list/literals-list.component';
import { LiteralAddComponent } from './components/literals/literal-add/literal-add.component';
import { LiteralVariablesComponent } from './components/literals/literal-variables/literal-variables.component';
import { LiteralValuesComponent } from './components/literals/literal-values/literal-values.component';
import { LiteralStatusComponent } from './components/literals/literal-status/literal-status.component';

@NgModule({
  declarations: [AppComponent, LiteralsComponent, SelectorsComponent, LiteralsListComponent, LiteralAddComponent, LiteralVariablesComponent, LiteralValuesComponent, LiteralStatusComponent],
  imports: [BrowserModule, AppRoutingModule, NgbModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
