import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LiteralsComponent } from './components/literals/literals.component';

const routes: Routes = [{ path: '', component: LiteralsComponent, pathMatch: 'full' }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
