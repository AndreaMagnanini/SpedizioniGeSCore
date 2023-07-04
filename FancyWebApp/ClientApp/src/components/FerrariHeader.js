import React from 'react';
import {
    AppBar,
    Drawer,
    List,
    ListItem, ListItemIcon,
    ListItemText,
    MenuItem,
    Toolbar,
    Typography,
    ThemeProvider, CssBaseline
} from "@material-ui/core";
import {makeStyles} from "@material-ui/core";
import MissonWinnowIcon from "./MissonWinnowIcon";
import {Select} from "@material-ui/core";
import {AddOutlined, HomeOutlined, ListOutlined} from "@material-ui/icons";
import MenuSharpIcon from '@material-ui/icons/MenuSharp';
import {ChevronRightSharp} from "@material-ui/icons";
import {useLocation, useNavigate} from "react-router-dom";
import {IconButton} from "@mui/material";
import FerrariTheme from "../styles/FerrariTheme";

const menuItems = [
    {
        text: "home",
        icon: <HomeOutlined color="primary"/>,
        path: "/"
    },
    {
        text: "shipments",
        icon: <ListOutlined color="primary"/>,
        path: "/shipments"
    },
    {
        text: "new",
        icon: <AddOutlined color="primary"/>,
        path: "/new"
    },
]
 const user = 'amagnanini'
const useStyles = makeStyles({
    root: {
        display: "flex"
    },
    appbar: {
        alignItems: "center",
        height: "60px",
        display: "flex",
        flexDirection: "row",
        justifyContent: "space-between",
        width: '100%',
        background: "linear-gradient(90deg, rgba(231,14,14,1) 0%, rgba(165,22,22,1) 66%)",
        position: "fixed",
    },
    toolbar: {
        flexGrow: 1,
        alignItems: "center",
    },
    page:{
        display: "block",
        width: "100%",
        height: "100%",
        marginTop: "60px",
        backgroundColor: "#212121"
    },
    logo:{
        width:"37px",
        height:"50px",
        marginTop: "10px",
        marginBottom: "10px",
        marginRight: "20px"
    },
    title:{
        textDecoration: "bold",
        paddingLeft: "20px",
        marginBottom: "5px",
        fontWeight: 500,
        fontSize: 30,
        width: "350px"
    },
    seasonSelect:{
        height: "40px",
        textAlign: "center",
        alignItems:"center",
    },
    items:{
        marginBottom: "17px",
        textAlign: "center"
    },
    item:{
        color: "secondary"
    },
    active: {
        background: "#412121",
        pointerEvents: "none"
    },
    userName:{
       paddingRight: "30px"
    },
    toggleDrawer: {
        width:40,
        height: 40,
    },
    drawer:{
    },
    paper:{
        flexDirection: "column",
        width: `300px`,
        background: "#212121",
        top: "60px"
    }
})

function FerrariHeader({children}) {
    const [open, setOpen] = React.useState(false);
    const navigate = useNavigate()
    const location = useLocation()
    const [season, setSeason] = React.useState(2023);
    const handleChange = (event) => {
        setSeason(event.target.value);
    };
    const [state, setState] = React.useState({
        right: false,
    });

    function itemClick (path) {
        setOpen(false);
        setState({ ...state, right: false });
        navigate(path);
    }
    const toggleDrawer = (open) => (event) => {
        if (event.type === 'keydown' && (event.key === 'Tab' || event.key === 'Shift')) {
            return;
        }
        setOpen(open);
        setState({ ...state, right: open });
    };
    const classes = useStyles()
    const availableSeasons = [2023, 2022, 2021];
    return (
        <ThemeProvider theme={FerrariTheme}>
            <CssBaseline />
        <div className={classes.root}>
            <AppBar className={classes.appbar} open={open}
                    s>
                <Toolbar>
                    <img className={classes.logo}
                        src={require('../assets/scuderia_ferrari_logo.png')} alt="Ferrari Logo">
                    </img>
                    <MissonWinnowIcon/>
                    <Typography className={classes.title}>
                        SpedizioniGeS
                    </Typography>
                    <Select
                        className={classes.seasonSelect}
                        onChange={handleChange}
                        variant="filled"
                        value={season}
                    >
                        {availableSeasons.map(season => (
                            <MenuItem value={season}>
                                <Typography className={classes.items}>
                                    {season}
                                </Typography>
                            </MenuItem>
                        ))}
                    </Select>

                </Toolbar>
                <Toolbar>
                    <Typography className={classes.userName}>
                        {user}
                    </Typography>
                    <IconButton
                        style={{marginRight: "10px", right:"0px"}}
                        className={classes.toggleDrawer}
                        onClick={toggleDrawer( true)}
                    >
                        {!open? <MenuSharpIcon fontSize="large" style={{ color: "#fafafa" }}/>
                            : <ChevronRightSharp fontSize="large" style={{ color: "#fafafa" }}/>}
                    </IconButton>
                </Toolbar>

                <Drawer
                    BackdropProps={{ invisible: true }}
                    variant="temporary"
                    className={classes.drawer}
                    classes = {{paper: classes.paper}}
                    anchor="right"
                    open={state["right"]}
                    onClose={toggleDrawer(false)}
                >
                    <List>
                        {menuItems.map(item => (
                            <ListItem key={item.text}
                                      button
                                      onClick={() => itemClick(item.path)}
                                      className={location.pathname === item.path ? classes.active : null}>
                                <ListItemIcon>{item.icon}</ListItemIcon>
                                <ListItemText disableTypography
                                              primary={<Typography variant="body2" style={{ color: '#fafafa' }}>{item.text}</Typography>}/>
                            </ListItem>
                        ))}
                    </List>
                </Drawer>
            </AppBar>
        </div>
            <div className={classes.page}>
                {React.cloneElement(children, {year: season})}
            </div>
        </ThemeProvider>
    );
}

export default FerrariHeader;