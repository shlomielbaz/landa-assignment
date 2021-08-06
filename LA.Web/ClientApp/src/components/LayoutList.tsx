import React, { Component, useContext, useEffect, useState } from "react";
import { useObserver, useLocalStore } from 'mobx-react'
import Dashboard from "./Dashboard";

import LayoutContext from "../contexts/layout.context";
import { Layout } from "react-grid-layout";


const LayoutList = () => {
    const store: any = useContext(LayoutContext);
    const [layouts, setLayouts] = useState([]);

    useEffect(() => {

        store.getLayouts().then((data: any) => {
            setLayouts(data)
        })

    }, []);

    return useObserver(() => (
        <React.Fragment>
            {
                layouts.length > 0 ? (
                    layouts.map((item, i) => (
                        <div key={i} style={{ transform: 'scale(0.5) translate(-50%, -50%)', border: '1px solid #eee' }}>
                            <Dashboard
                                layout={item}
                                cols={12}
                                maxRows={8}
                                preventCollision={true} />
                        </div>
                    ))
                ) : "There is no default layout set, please go to configuration page to set one"
            }
        </React.Fragment>
    ))
}

export default LayoutList;
