import React, { Component, useContext, useEffect, useState } from "react";
import { useObserver, useLocalStore } from 'mobx-react'
import Dashboard from "../components/Dashboard";

import LayoutContext from "../contexts/layout.context";
import { Layout } from "react-grid-layout";

const Home = () => {
  const store: any = useContext(LayoutContext);
  const [layout, setLayout] = useState([]);

  useEffect(() => {

    store.getLayout().then((data: any) => {
      setLayout(data)
    })

  }, []);

  return useObserver(() => (
    <React.Fragment>
      {
        layout.length > 0 ? (<Dashboard
            layout={
              layout && layout.map((item: Layout) => ({
                ...item,
                static: true
              }))
            }
            cols={12}
            maxRows={8}
            preventCollision={true}
          />)
          : "There is no default layout set, please go to configuration page to set one"
      }
    </React.Fragment>
  ))
}
export default Home;
