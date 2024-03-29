import { Component, Output, EventEmitter, OnInit, ViewChild, ElementRef } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { UsuarioService } from "../../../services/http/usuario.service";
import { Usuario } from "../../../models/usuario.model";

@Component({
selector: '[upload-form]',
templateUrl: 'upload-form.html'
})
export class UploadFormComponent implements OnInit{

    @Output('onItemsAdd') public itemsEmitter: EventEmitter<any> = new EventEmitter<any>();
    @ViewChild('inputFile') public inputFile: ElementRef;
    public arquivoFormGroup: FormGroup;
    private indexRaw: number;
    public arquivosUploadListArray: any[] = [];
    public fileList = [];
    constructor(public fb: FormBuilder, private usuariosService: UsuarioService) {}

    readFiles(event) {

        this.fileList = event.target.files;
        console.log(this.fileList);
    }

    onData_ReferenciaSelect(event) {
        this.arquivoFormGroup.controls["Data_Referencia"]
        .setValue(event.year + "-" + ("0" + parseInt(event.month)).slice(-2) + "-" + ("0" + parseInt(event.day)).slice(-2)); 
    }


    /// Insere objetos de upload na lista 
    //
    //
    //
    Submit(event) {
         
             event.preventDefault();

             this.indexRaw = 0;
             console.log(this.fileList);
             this.usuariosService.get().subscribe((usuarios:Usuario[]) => {

                for(let i = 0; i < this.fileList[i].length; i++) {
    
                     
                      for(let uI = 0; uI < usuarios.length; uI++) {
    
                      if(usuarios[uI].Matricula ==  this.fileList[i].name.split("-")[4]) {
    
                                  this.arquivosUploadListArray.push({
                                              index : this.indexRaw,
                                              Arquivo: this.arquivoFormGroup.value.Arquivos[i],
                                              Usuario_Id: usuarios[uI].Id,
                                              Matricula: usuarios[uI].Matricula,
                                              TipoDoc: this.arquivoFormGroup.value.TipoDoc,
                                              Ext:  this.arquivoFormGroup.value.Arquivos[i].name.split(".")[1],
                                              ArquivoNome:  this.arquivoFormGroup.value.TipoDoc 
                                              + "-" + this.arquivoFormGroup.value.Data_Referencia,
                                              UsuarioNome : usuarios[uI].Nome,
                                              Descricao: this.arquivoFormGroup.value.Descricao,
                                              Data_Referencia: this.arquivoFormGroup.value.Data_Referencia,
                                        })
    
                                        this.indexRaw = this.indexRaw + 1;
    
    
                            }
                     }  
                }
                this.itemsEmitter.emit(this.arquivosUploadListArray);
                this.arquivosUploadListArray = [];
                this.arquivoFormGroup.reset();
                this.inputFile.nativeElement.value = "";
          })

    }

    ngOnInit() {
        this.arquivoFormGroup = this.fb.group({

            Data_Referencia: ["", [Validators.required]],
            TipoDoc: ["", [Validators.required]],
            Descricao: ["", [Validators.maxLength(400)]]
        
          });
    }

}