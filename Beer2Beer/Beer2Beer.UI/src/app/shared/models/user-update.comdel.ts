export class UserUpdate {
    
    constructor(
        public id:number=0,
        public firstname:string="",
        public lastname:string="",
        public passwordHash:string = ""
    ){}
}
