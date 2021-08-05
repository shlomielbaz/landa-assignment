import { observable, action, computed, runInAction } from 'mobx';
import Layout from '../interfaces/layout.interface';

class LayoutStore {
    @observable private _layout: Layout[] = [
        {  i: "#760496", x: 0, y: 0, w: 8, h: 1 },
        {  i: "#71510c", x: 4, y: 0, w: 4, h: 1 },
        {  i: "#5ed3c2", x: 8, y: 0, w: 4, h: 1 },
        {  i: "#50b09c", x: 0, y: 1, w: 4, h: 1 },
        {  i: "#4975ce", x: 4, y: 1, w: 4, h: 1 },
        {  i: "#098e94", x: 8, y: 1, w: 4, h: 1 }
    ];

    get layout() {
        return this._layout;
    }

    set layout(v: any) {
        this._layout = v;
    }

    @action async fetchLayout(layout: Layout[]) {
        console.log(layout)
        // const characterId = ++this.id
        

        const response = await fetch(`/api/layouts`, {
            method: 'POST', // *GET, POST, PUT, DELETE, etc.
            mode: 'cors', // no-cors, *cors, same-origin
            cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
            credentials: 'same-origin', // include, *same-origin, omit
            headers: {
              'Content-Type': 'application/json'
              // 'Content-Type': 'application/x-www-form-urlencoded',
            },
            redirect: 'follow', // manual, *follow, error
            referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
            body: JSON.stringify(layout) // body data type must match "Content-Type" header
          });


        // const data = await response.json()
        // this.setImageUrl(data.image)

        // runInAction(() => {
        //     this.imageUrl = data.image
        // })
    }

    @action async getLayout(layout: Layout[]) {
        const response = await fetch(`/api/layouts`, );

        
    
        // const data = await response.json()
        // this.setImageUrl(data.image)

        runInAction(() => {
            this.layout = response;
        })
    }

}

const storeInstance = new LayoutStore()

export default storeInstance;