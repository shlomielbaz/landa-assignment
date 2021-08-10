import { observable, action, computed, runInAction } from 'mobx';
import Layout from '../interfaces/layout.interface';

class LayoutStore {
    @observable 
    private layout: Layout[] = [];

    // get layout() {
    //     return this._layout;
    // }

    // set layout(v: any) {
    //     this._layout = v;
    // }

    @action 
    async saveLayout(layout: Layout[]) {
        const response = await fetch(`/api/layouts`, {
            method: 'POST',
            mode: 'cors',
            cache: 'no-cache',
            credentials: 'same-origin',
            headers: {
                'Content-Type': 'application/json'
            },
            redirect: 'follow',
            referrerPolicy: 'no-referrer',
            body: JSON.stringify(layout)
        });
    }

    @action
    async getLayout(layout: Layout[]) {
        // this is fake id, the reason to use it is for get the GET API for retreave one!
        const response = await fetch(`/api/layouts/1`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then(response => response.json())
            .then((data: any) => {
                return data && JSON.parse(data.content) || [];
            });

        runInAction(() => {
            this.layout = response;
        })
        return response;
    }

    @action
    async getLayouts(layout: Layout[]) {
        // this is fake id, the reason to use it is for get the GET API for retreave one!
        const response = await fetch(`/api/layouts`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then(response => response.json())
            .then((data: any) => {
                return data && data.map((item: any) => JSON.parse(item.content)) || [];
            });

        runInAction(() => {
            this.layout = response;
        });
        return response;
    }

}

const storeInstance = new LayoutStore()

export default storeInstance;