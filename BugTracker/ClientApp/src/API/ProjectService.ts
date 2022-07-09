import axios from 'axios'

export default class ProjectService {
    static async CreateProject(title:string, description:string, ) {
        axios.post('/createproject', {
            
        })
    }
}