import * as React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Configuration from './components/Configuration';
import LayoutList from './components/LayoutList';

import './custom.css';
import '../node_modules/react-grid-layout/css/styles.css';
import '../node_modules/react-resizable/css/styles.css';

export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route exact path='/home' component={Home} />
        <Route path='/configuration' component={Configuration} />
        <Route path='/list' component={LayoutList} />
    </Layout>
);
