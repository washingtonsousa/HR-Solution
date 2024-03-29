import { Component, Input, EventEmitter, ViewChild, Output, OnInit, OnChanges} from "@angular/core";
import { Resumo } from "../../../../models/resumo.model";
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ResumoService } from "../../../../services/http/resumo.service";
import { LoadingIconService } from "src/app/services/emitters/loading-icon.service";

@Component({
selector: '[resumo-form]',
templateUrl: 'resumo_form.html'
})
export class ResumoFormComponent  implements OnInit {

   @Input() public resumo: Resumo;
   @Input() public buttonText: string = "Salvar";
   @Output('OnSubmit') public emitter: EventEmitter<any> =  new EventEmitter<any>();
   public  ResumoForm:FormGroup;
   Message: string;
   constructor(private fb: FormBuilder, private resumoService: ResumoService) {}

   ngOnInit() {
       
   if(!this.resumo.UsuarioId) {
       this.resumo.UsuarioId = parseInt(localStorage.getItem('user_id'));
   }

   this.ResumoForm = this.fb.group({
        Id: [this.resumo.Id],
        Conteudo : [this.resumo.Conteudo, Validators.required],
        UsuarioId: [this.resumo.UsuarioId, Validators.required]
       });
   }

   OnSubmit(event) {

   event.preventDefault();

   if(this.ResumoForm.valid) {

        LoadingIconService.show();

            this.resumoService.post(this.ResumoForm.value).subscribe(res => { 
                this.emitter.emit(res);
                LoadingIconService.hide();
                this.Message= "Executado com sucesso";

            }, err => {
                this.resumoService.put(this.ResumoForm.value).subscribe((res) => {

                    LoadingIconService.hide();
                    this.emitter.emit(res);
                    this.Message= "Executado com sucesso";

            }, err => {
                
                
                this.Message= "Ocorreu um erro"; LoadingIconService.hide();})

                

            });

        }
    }

}