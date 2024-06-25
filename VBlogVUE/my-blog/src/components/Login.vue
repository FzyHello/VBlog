<template>
  <div class="login">
    <div class="login-box">
      <el-form ref="loginForm" :model="userInfo" label-width="auto">
        <el-form>
          <h2>Login</h2>
        </el-form>
        <el-form-item prop="username">
          <el-input
            v-model="userInfo.username"
            placeholder="账号"
            prefix-icon="Avatar"
          />
        </el-form-item>
        <el-form-item prop="password">
          <el-input
            type="password"
            placeholder="密码"
            v-model="userInfo.password"
            prefix-icon="Key"
          />
        </el-form-item>
        <el-form-item>
          <div class="login-btn">
            <el-button type="primary" @click="loginSubmit()">登录</el-button>
          </div>
        </el-form-item>
      </el-form>
      <div class="login-box-register">
        <el-link type="info" :underline="false">注册账号</el-link>
      </div>
    </div>
  </div>
</template>

<script setup name="LoginBox">
import { ref, reactive } from "vue";
import { Post } from "@/service/baseService.ts";
import { useRouter } from "vue-router";

const router = useRouter();

let userInfo = reactive({
  username: "",
  password: "",
});

function loginSubmit() {
  // 账号 admin 密码 123456
  // Post("http://localhost:5214/Login", userInfo).then((res) => {
  //   console.log(res.data);
  // });
  router.push("/Blog");
}
</script>

<style lang="scss" scoped>
::v-deep .login-btn > .el-button {
  width: 100%;
}
::v-deep .login-box-register > .el-link {
  color: #dfdddd;
}
.login {
  height: 100vh;
  width: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  background-image: url("@/assets/img/login-Bg.jpg");
  background-size: cover;
  background-position: center;
  &-box {
    width: 450px;
    height: 300px;
    margin: 20px 20px 20px 10px;
    padding: 0 20px;
    display: flex;
    justify-content: center;
    flex-direction: column;
    align-items: center;
    text-align: center;
    backdrop-filter: blur(10px) brightness(90%);
    background-color: rgba(255, 255, 255, 0.5);
    border-radius: 10px;
    &-register {
      width: 100%;
      text-align: left;
    }
  }
  &-btn {
    width: 100%;
    display: flex;
    justify-content: center;
  }
}
</style>
