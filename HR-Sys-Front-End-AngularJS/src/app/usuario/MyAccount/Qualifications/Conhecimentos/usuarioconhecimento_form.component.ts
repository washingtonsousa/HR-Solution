import { Component, Input, ViewChild, OnChanges } from "@angular/core";
import {UsuarioConhecimentoModel} from '../../../../models/UsuarioConhecimento.model';
import { UsuarioConhecimentoService } from "../../../../services/http/usuarioconhecimento.service";
import { trigger, state , transition, animate, style} from '@angular/animations';
import { CategoriaConhecimentoService } from "../../../../services/http/categoriaConhecimento.service";
import { CategoriaConhecimentoModel } from "../../../../models/CategoriaConhecimento.model";

@Component({
selector: '[usuarioconhecimento-form]',
templateUrl: 'usuarioconhecimento_form.html',
animations:[
    trigger('verticalOpen',[
        state('inactive',style({
            opacity:'0',
            height: '0px'
        })),
        state('active',style({
            opacity:'1',
            height: '100%'
        })),
        transition('active => inactive', animate('100ms ease-in')),
        transition('inactive => active', animate('100ms ease-out'))
    ])
]
})
export class UsuarioConhecimentoFormComponent implements OnChanges {

    @Input() public UsuarioConhecimentoList: UsuarioConhecimentoModel[] = [] || [];
    public categoriaConhecimentos: CategoriaConhecimentoModel[] = [];

    public state: string = "inactive";
    private JsonObjectIdsObject = {

     "UsuarioId" : parseInt(localStorage.getItem('user_id')),
     "ConhecimentoIds" : []

    };
    @Input() public buttonText: string;
    @ViewChild('loadingIcon') loadingIcon: any
 
    constructor(
    private UsuarioConhecimentoService: UsuarioConhecimentoService,
    private categoriaConhecimentoService: CategoriaConhecimentoService) {}


    animateList() {
        this.state = (this.state === 'inactive' ? 'active' : 'inactive');
    }

    OnSubmit() {

           this.loadingIcon.show();
           this.UsuarioConhecimentoService.post(this.JsonObjectIdsObject).subscribe(res => {

                this.loadingIcon.hide();

           }, err => {this.loadingIcon.hide();})
    }

    OnCheck(value) {

        if(!this.JsonObjectIdsObject.ConhecimentoIds.includes(value)) {
            this.JsonObjectIdsObject.ConhecimentoIds.push(value);
        }  else {

            for(let i = 0; i < this.JsonObjectIdsObject.ConhecimentoIds.length; i++) {
        
                if(this.JsonObjectIdsObject.ConhecimentoIds[i] == value) {
        
                  this.JsonObjectIdsObject.ConhecimentoIds.splice(i, 1);
                }
              
            }
            
          }
    }



    ngOnChanges() {

        for(let $i = 0; $i < this.UsuarioConhecimentoList.length; $i++) {

            this.JsonObjectIdsObject.ConhecimentoIds.push(this.UsuarioConhecimentoList[$i].ConhecimentoId);

        }


       this.categoriaConhecimentoService.get().subscribe((res) => {

           this.categoriaConhecimentos = res;
      
       }, err => {

       })
    }

}