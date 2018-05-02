<template>
    <div class="header">
      <!-- header start -->
        <div class="optbox">
            <div class="wd1200">
                <div class="loginedbox">
                    <span v-if="userInfo">您好！</span>
                    <span class="loginbtn">
                        <router-link to="/user" v-if="userInfo">{{ userInfo.Account }}</router-link>
                        <router-link to="/login" v-if="!userInfo">请登录</router-link>
                    </span>
                    <span class="loginout" @click="logout" v-if="userInfo">[退出]</span>
                    <span class="center">
                        <router-link to="/order" v-if="userInfo">个人中心</router-link>
                        <router-link style="color: #333" to="/register" v-if="!userInfo">免费注册</router-link>
                    </span>
                </div>
            </div>
        </div>
        <div class="wd1200 searchbox">
            <el-row>
                <el-col :span="8"><div class="grid-content bg-purple">
                <router-link to="/index"><img src="~assets/images/logo.png" class="logo"></router-link></div></el-col>
                <el-col :span="16">
                    <div class="grid-content bg-purple-light seabox">
                        <el-input placeholder="关键词搜索" prefix-icon="el-icon-search" v-model="keywords" @keyup.enter.native="search"></el-input>
                        <el-button class="sea-btn" @click="search">搜索</el-button>
                    </div>
                </el-col>
            </el-row>
        </div>
        <div class="navbox">
            <el-header>
                <div class="wd1200">
                    <el-menu :default-active="activeIndex" class="el-menu-demo" mode="horizontal" @select="handleSelect" background-color="#261f1e" text-color="#fff" active-text-color="#f9513b">
                        <el-menu-item index="0">首页</el-menu-item>
                        <el-menu-item
                            v-for="(menu, index) in activityTypes"
                            :index="(index + 1).toString()"
                            :key="index">
                        {{ menu+"商品" }}
                        </el-menu-item>
                    </el-menu>
                </div>
            </el-header>
        </div>
        <!-- header end -->
    </div>
</template>

<script>
  import { mapGetters, mapActions } from 'vuex'

  import { api as ajax } from 'services'

  export default {
    name: 'MainHeader',
    data() {
      return {
        activeIndex: '0',
        keywords: '',
        userInfo:{},
      }
    },
    computed: {
      ...mapGetters([
        'account',
        'activityTypes'
      ])
    },
    mounted(){

    },
    created() {
        let cookieInfo = this.util.getCookie('user')?JSON.parse(this.util.getCookie('user').slice(1)):'';
        this.userInfo = cookieInfo;
        console.log(this.userInfo)
        if(sessionStorage.getItem('prePath')!=='/login'&&sessionStorage.getItem('prePath')!=='/index'&&sessionStorage.getItem('prePath')!=='/') {
            this.activeIndex = sessionStorage.getItem('typekey');
            this.$emit('clickType',sessionStorage.getItem('typename'));
        }else {
            this.getActivityTypes();
        }
    },
    methods: {
      ...mapActions([
        'setAccount',
        'setActivityTypes'
      ]),
      handleSelect(key, keyPath) {
          let name = "";
          key === '0'?name = "":name = this.activityTypes[key-1];
          this.$emit('clickType',name);
          sessionStorage.setItem('typekey',key);
          sessionStorage.setItem('typename',name);
          this.$router.push('/index')
      },
      logout() {
        ajax.logout().then((result) =>{
            //this.$message.success('将为你返回登录页面')
//             localStorage.removeItem('user');
            this.util.clearCookie('user')
            this.$router.push('/login')
        })

      },
      getActivityTypes() {
        if (this.activityTypes.length > 0) return
          ajax.getActivityTypes().then((result) => {
              this.setActivityTypes(result)
          })
      },
      search() {
        this.$router.push('/index?keywords=' + this.keywords)
      }
    }
  }
</script>

<style scoped>
.clear:after{content:'';display:block;clear:both;height:0;overflow:hidden;visibility:hidden;}
.clear{zoom:1;}
.optbox{
  background-color: #f2f2f2;
    height: 40px;
    line-height:40px;
    font-size:14px;
}
.optbox span{
  cursor:pointer;
}
.optbox span.loginbtn{
  color:#fe3026;
  margin-right:25px;
}
.optbox span.loginbtn a {
  color:#fe3026;
}
.seabox{
  margin-top:18px;
}
.searchbox{
   padding:20px 0;
}
.searchbox .logo{
  height:69px;
}
.searchbox  .el-input{
  width:280px;
  float:left;
}
.searchbox  .el-input input{
  border-radius:4px 0 0 4px;
  border-color:#f9513b;
  border-width:2px;
}
.searchbox .sea-btn{
  background:#f9513b;
  color:#fff;
  border:none;
  float:left;
  border-radius:0 4px 4px 0;
  height:40px;
  font-size:16px;
}
.navbox .el-header{
  height:50px !important;
  padding:0;
  background:#261f1e;
  font-size:16px;
}
.navbox .el-menu--horizontal>.el-menu-item{
  height:50px;
  line-height:50px;
  margin-right:30px;
}
 .loginedbox{
     color:#666;
  }
  .account{
     color:#f84933;
     margin:0 20px 0 15px;
     font-size:14px;
  }
  .loginout{
     margin-right:20px;
  }
  .center a{
    color:#666;
   }
  .center a:hover{
     color:#f84933;
  }
  .loginout:hover{
     color:#f84933;
  }
  </style>
